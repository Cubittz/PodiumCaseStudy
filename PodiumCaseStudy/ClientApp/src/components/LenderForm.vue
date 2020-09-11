<template>
  <div>
    <div class='row'>
      <div class='col-md-6 mx-auto'>
        <h2 v-if='step === 1'>Enter your personal details</h2>
        <h2 v-if='step === 2'>Enter your property details</h2>
      </div>
    </div>
    <div class='row'>
      <div class='col-md-6 mx-auto'>
        <div id='form-1' v-if='step === 1'>
          <loading :active.sync='isLoading' :is-full-page='fullPage'></loading>
          <div class='form-group'>
            <label>First Name</label>
            <input type='text' class='form-control' v-model='applicant.firstName' />
          </div>
          <div class='form-group'>
            <label>Last Name</label>
            <input type='text' class='form-control' v-model='applicant.lastName' />
          </div>
          <div class='form-group'>
            <label>Date of Birth</label>
            <input type='date' class='form-control' v-model='applicant.dateOfBirth' />
          </div>
          <div class='form-group'>
            <label>Email</label>
            <input type='email' class='form-control' v-model='applicant.email' />
          </div>
        </div>
        <div id='form-2' v-if='step === 2'>
          <div class='form-group'>
            <label>Property Value</label>
            <input
              type='text'
              class='form-control'
              v-model='mortgageRequirement.propertyValue'
            />
          </div>
          <div class='form-group'>
            <label>Deposit Amount</label>
            <input
              type='text'
              class='form-control'
              v-model='mortgageRequirement.depositAmount'
            />
          </div>
        </div>
        <lender-list v-if='step === 3' v-bind:lenders='this.lenders'/>
        <div class='form-group'>
          <button
            type='button'
            class='btn btn-primary'
            @click='previousStep'
            v-if='step > 1'
          >Previous</button>
        </div>
        <div class='form-group'>
          <button
            type='button'
            class='btn btn-primary'
            v-show='stepButtonText'
            @click='nextStep'
            v-if='step < 3'
          >{{ stepButtonText }}</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import applicantService from '@/services/applicantService';
import mortgageProposalService from '@/services/mortgageProposalService';
import Loading from 'vue-loading-overlay';
import 'vue-loading-overlay/dist/vue-loading.css';
import LenderList from '@/components/LenderList';

export default {
  name: 'LenderForm',
  data: function () {
    return {
      step: 1,
      applicant: {
        firstName: '',
        lastName: '',
        dateOfBirth: Date.now(),
        email: '',
      },
      mortgageRequirement: {
        applicantId: '',
        propertyValue: 0.0,
        depositAmount: 0.0,
      },
      lenders: [],
      isLoading: false,
      fullPage: true,
    };
  },
  computed: {
    stepButtonText() {
      return this.step === 1 ? 'Continue' : 'Calculate';
    },
  },
  components: {
    Loading,
    LenderList
  },
  methods: {
    nextStep() {
      if (this.step === 1) {
        this.isLoading = true;
        console.log(this.applicant);
        applicantService.createApplicant(JSON.stringify(this.applicant))
          .then((response) => {
            if (this.step >= 1 && this.step < 3) this.step++;
            this.mortgageRequirement.applicantId = response.data.id;
          })
          .catch((error) => {
            console.log(error.response);
          })
          .finally(() => (this.isLoading = false));
      }

      if (this.step === 2) {
        this.isLoading = true;
        console.log(this.mortgageRequirement);
        mortgageProposalService.getMatchingLoansForUser(this.mortgageRequirement)
          .then((response) => {
            this.lenders = response.data;
            this.step = 3;
          })
          .catch((error) => {
            console.log(error.response);
          })
          .finally(() => (this.isLoading = false));
      }
    },
    previousStep() {
      if (this.step >= 1) this.step--;
    },
  },
};
</script>
