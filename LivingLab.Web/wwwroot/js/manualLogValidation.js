// // run your script after entire web is generated
// document.addEventListener("DOMContentLoaded", function() {}

/**
 * Validate fields
 * 
 * @returns true if all fields are valid, false otherwise
 */
function validate() {
    const $deviceId = $(".deviceId");
    const $energyUsage = $(".energyUsage");
    const $duration = $(".duration");
    const $loggedAt = $(".loggedAt");
    const $errorElement = $("#error");
    let messages = [];
    
    checkEmpty($deviceId, messages);
    checkEmpty($energyUsage, messages);
    checkEmpty($duration, messages);
    checkEmpty($loggedAt, messages);
    
    if (messages.length > 0) {
        $errorElement.html(messages.join("</br>"));
        return false;
    }
    
    return true
}

/**
 * Check if all inputs are empty or null
 * 
 * @param $inputs
 * @param messages
 */
function checkEmpty($inputs, messages) {
    $inputs.each(function() {
        if ($(this).val() === '' || $(this).val() === null){
            const text = $(this).attr('name') + ' is required';
            if (messages.indexOf(text) === -1) {
                messages.push(text);
            }
        }
    });
}
