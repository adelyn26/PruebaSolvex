import Axios from 'axios'
import clienteService from '../services/ClienteService'

let apiUrl = 'https://localhost:44357/'
// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    clienteService: new clienteService(Axios, apiUrl)
}