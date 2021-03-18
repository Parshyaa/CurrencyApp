<template>
    <v-app>
        <Currency />
    </v-app>
</template>

<script>
    import Currency from './components/CurrencyComponent.vue'

    export default {
        name: 'app',
        components: {
            Currency
        }
    }
</script>

<style>
    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>
