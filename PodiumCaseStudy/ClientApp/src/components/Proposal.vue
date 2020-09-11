<template>
  <div id='results'>
  <h2>Your mortgage proposal</h2>
    <table class='table table-bordered'>
      <thead>
        <tr>
          <th scope='col'>Lender</th>
          <th scope='col'>Interest Rate</th>
          <th scope='col'>Fixed/Variable</th>
          <th scope='col'>Loan-to-value</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for='proposal in lenders' :key='proposal.product.id'>
          <th scope='row'>{{proposal.product.lender}}</th>
          <td>{{proposal.product.interestRate | toPercentage}}</td>
          <td>{{proposal.product.loanType}}</td>
          <td>{{proposal.product.loanToValue | toPercentage}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: 'proposal',
  props: ['lenders'],
  filters: {
    toPercentage(number) {
      return parseFloat(number).toFixed(2) + '%';
    },
  },
};
</script>
