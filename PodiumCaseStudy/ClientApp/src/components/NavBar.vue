<template>
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
    <div class="container-fluid">
  <a class='navbar-brand nav-link' href='#'>Podium Test</a>
  <button class='navbar-toggler' type='button' data-toggle='collapse'
    data-target='.navbar-collapse' aria-controls='.navbar-collapse'
    aria-expanded='false' aria-label='Toggle navigation'>
    <span class='navbar-toggler-icon'></span>
  </button>

  <div class='navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse' id='navbar-collapse'>
    <ul class='navbar-nav mr-auto'>
      <li class='nav-item active'>
        <router-link to='/' class='nav-link'>Home</router-link>
      </li>
    </ul>
  </div>
  </div>
</nav>
</template>

<script>
export default {
  name: 'NavBar',
};
</script>
