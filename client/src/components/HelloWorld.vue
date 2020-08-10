<template>
  <div class="hello">
    <h1>Weather forecast</h1>
    <div class="tablau">
      <table>
        <tr>
          <th>Date</th>
          <th>Temperature</th>
          <th>Summary</th>
        </tr>
        <tr v-for="w in weather" :key="w.id">
          <td>{{ new Date(w.date).toDateString() }}</td>
          <td>{{ w.temperatureC }}°C</td>
          <td>{{ w.summary }}</td>
        </tr>
      </table>
    </div>

  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  methods: {
    async getWeather() {
        this.weather = await fetch('/api/weather')
          .then(res => res.json())
          .catch(res => console.error(res));
    }
  },
  data() {
    return {
      weather: []
    }
  },
  mounted() {
    this.getWeather();
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

.tablau {
  max-width: 700px;
  margin: auto;
}
</style>
