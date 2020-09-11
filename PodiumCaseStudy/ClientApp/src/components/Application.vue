<template>
  <div>
    <div class='row'>
      <div class='col-md-6 mx-auto'>    
        <div id='applicantForm' v-if='step === 1'>
          <h2>Applicant details</h2>
          <hr/>
          <form>
            <div class='form-group row'>
              <label class="col-sm-4" for="firstName">First Name</label>
              <input name="firstName" id="firstName" type='text' class='form-control col-sm-8' v-model='applicant.firstName' />
            </div>
            <div class='form-group row'>
              <label class="col-sm-4">Last Name</label>
              <input type='text' class='form-control col-sm-8' v-model='applicant.lastName' />
            </div>
            <div class='form-group row'>
              <label class="col-sm-4">Date of Birth</label>
              <input type='date' class='form-control col-sm-8' v-model='applicant.dateOfBirth' />
            </div>
            <div class='form-group row'>
              <label class="col-sm-4">Email</label>
              <input type='email' class='form-control col-sm-8' v-model='applicant.email' />
            </div>
          </form>
        </div>
        <div id='requirementForm' v-if='step === 2'>     
          <h2>Mortgage Requirement</h2>
          <hr/>
          <form>
            <div class='form-group row'>
              <label class="col-sm-4">Property Value</label>
              <input
                type='text'
                class='form-control col-sm-8'
                v-model='mortgageRequirement.propertyValue'
              />
            </div>
            <div class='form-group row'>
              <label class="col-sm-4">Deposit Amount</label>
              <input
                type='text'
                class='form-control col-sm-8'
                v-model='mortgageRequirement.depositAmount'
              />
            </div>
          </form>
        </div>
        <proposal v-if='step === 3' v-bind:lenders='this.lenders'/>
        <div class='form-group'>
          <button
            type='button'
            class='btn btn-warning'
            @click='previousStep'
            v-if='step > 1'
          >Previous</button>
        </div>
        <div class='form-group'>
          <button
            type='button'
            class='btn btn-success'
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
import Proposal from '@/components/Proposal';

export default {
  name: 'Application',
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
      fullPage: true,
    };
  },
  computed: {
    stepButtonText() {
      return this.step === 1 ? 'Next' : 'Get Proposal';
    },
  },
  components: {
    Proposal
  },
  methods: {
    nextStep() {
      if (this.step === 1) {
        applicantService.createApplicant(JSON.stringify(this.applicant))
          .then((response) => {
            if (this.step < 3) {
              this.step++;
            }
            this.mortgageRequirement.applicantId = response.data.id;
          })
          .catch((error) => {
            console.log(error.response);
          });
      }

      if (this.step === 2) {
        mortgageProposalService.getProposal(this.mortgageRequirement)
          .then((response) => {
            this.lenders = response.data.products;      
            this.step = 3;
          })
          .catch((error) => {
            console.log(error.response);
          });
      }
    },
    previousStep() {
      if (this.step >= 1) {
        this.step--;
      }
    },
  },
};
</script>
