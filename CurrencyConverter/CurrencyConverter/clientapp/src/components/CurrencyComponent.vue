<template>
    <v-container max-width="60px">
        <v-row>
            <v-col cols="10" md="12" lg="9" xl="6" class="bg--light mx-auto">
                <h1 class="text-center mb-4">Click on Button to get the rate of USD to EUR</h1>
                <v-btn class="ma-2"
                       outlined
                       color="indigo" @click="getRate">
                    Click Here
                </v-btn>
                <h3 class="text-center mb-4">{{message}}</h3>
            </v-col>
        </v-row>
    </v-container>
</template>
<script>
    import currencyService from "@/api/CurrencyApi";
    export default {
        name: "Currency",
        data() {
            return {
                message: '',
            }
        },
        methods: {
            getRate() {
                currencyService.getRate()
                    .then((resp) => {
                        if (resp !== undefined) {
                            this.message = "The currency rate of 1 USD to 1 EUR is "+ resp.data;
                        }
                    })
            }
        }
    }
</script>