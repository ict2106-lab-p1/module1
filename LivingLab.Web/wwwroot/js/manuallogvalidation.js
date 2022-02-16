// // run your script after entire web is generated
// document.addEventListener("DOMContentLoaded", function() {}

const deviceId = document.getElementById('deviceId')
const duration = document.getElementById('duration')
const form = document.getElementById('form')
const errorElement = document.getElementById('error')

function performValidation()
{
    form.addEventListener('submit', (e) => {

        // list to store the error messages
        let messages = []

        // validation
        // if device ID field is an empty string or user did not pass in any device Id
        if (deviceId.value === '' || deviceId.value == null) {
            // send the error message
            messages.push('Device ID is required')
            console.log('No Device ID retrieved')
        }

        // if there is error, prevent the form from submitting
        if (messages.length > 0) {
            e.preventDefault()

            // check errorElement
            errorElement.innerText = messages.join(', ') // to separate error elements from each other
        }
    })
}


