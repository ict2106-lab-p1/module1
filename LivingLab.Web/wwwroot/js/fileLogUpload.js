const template = `<div class="log-div mt-5 flex flex-col bg-white p-5 shadow-lg rounded gap-4">
                    <div class="flex justify-between mb-3">
                        <span class="serial-no font-bold text-center">{deviceSerialNumber}</span>
                        <div class="justify-end">
                            <button type="button" class="delete text-red-500 hover:bg-red-100 hover:scale-125 rounded-full p-2 ease-in-out duration-500">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="inherit" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <line x1="18" y1="6" x2="6" y2="18"></line>
                                    <line x1="6" y1="6" x2="18" y2="18"></line>
                                </svg>
                            </button>
                        </div>
                    </div>
                    <div class="flex flex-col lg:flex-row justify-between space-y-2 lg:space-x-3">
                        <div class="flex flex-row lg:flex-col justify-center space-x-2 lg:space-y-2">
                            <h3 class="text-center text-gray-600 m-auto lg:m-0">Energy Usage (J)</h3>
                            <input class="energyUsage input input-bordered w-full max-w-xs" name="Energy Usage" type="number" value="" placeholder="Enter Energy Usage (J)" required/>
                        </div>
                        <div class="flex flex-row lg:flex-col justify-center space-x-2 lg:space-y-2">
                            <h3 class="text-center text-gray-600 m-auto lg:m-0">Interval (min)</h3>
                            <input class="interval input input-bordered w-full max-w-xs" name="Interval" type="number" value="" placeholder="Enter Interval (min)" required/>
                        </div>
                        <div class="flex flex-row lg:flex-col justify-center space-x-2 lg:space-y-2">
                            <h3 class="text-center text-gray-600 m-auto lg:m-0">Logged At</h3>
                            <input class="loggedAt input input-bordered w-full max-w-xs" name="Logged At" type="datetime-local" value="" placeholder="Enter Logged At Datetime" required/>
                        </div>
                    </div>
                </div>`;

/**
 * When DOM is ready for JS code to execute.
 */
$(document).ready(function () {
  $("#fileUpload").change(fileChange);
  $("#btnAdd").click(appendRow);
  $(this).on("click", ".delete", deleteRow);
  $(".btnSave").click(save);
  $("#btn-submit").click(submit);
});

/**
 * File upload on change event.
 *
 * 1. Hide svg icon
 * 2. Replace file upload text with file name
 * 3. Show upload button
 *
 * @param e
 */
function fileChange(e) {
  const fileName = e.target.files[0].name;
  const fileSizeBytes = e.target.files[0].size;
  const fileSizeKb = fileSizeBytes / 1024;

  $("#attachmentText").text(`${fileName} (${fileSizeKb.toFixed(2)} KB)`);
  $("#btn-submit").show();
}

/**
 * Appends a new div for input.
 */
function appendRow() {
  const $form = $("#fileUploadForm");
  const deviceSerialNumber = $("#deviceSerialNumber").val();
  const updatedTemplate = template.replace(
    "{deviceSerialNumber}",
    deviceSerialNumber
  );

  if ($form.find("div.log-div").length === 0) $form.prepend(updatedTemplate);
  else $form.find("div.log-div:last").after(updatedTemplate);
}

/**
 * Remove the selected row from the table
 * and update the row number accordingly.
 */
function deleteRow() {
  $(this).closest("div.log-div").remove();
}

/**
 * Disable the submit button
 */
function disableUploadBtn() {
    const $uploadBtn = $("#btn-submit");
    $uploadBtn.removeClass("btn-primary").addClass("btn-disabled");
}

/**
 * Enable the submit button
 */
function enableUploadBtn() {
    const $uploadBtn = $("#btn-submit");
    $uploadBtn.removeClass("btn-disabled").addClass("btn-primary");
}

/**
 * Save the data to the database.
 */
function submit(e) {
  e.preventDefault();
  disableUploadBtn();
  const file = $("#fileUpload")[0].files[0];
  const formData = new FormData();
  formData.append("file", file);

  $("#progressBarContainer").removeClass("hidden")
  const $progressBar = $("#progressBar");
  $progressBar.show();
  
  $.ajax({
    url: "/ManualLogs/Upload",
    type: "POST",
    data: formData,
    processData: false,
    contentType: false,
    success: function (count) {
        $progressBar.removeClass("w-0");
        $progressBar.addClass("w-full");
        setTimeout(() => {
            Swal.fire({
            title: "Success!",
            text: `${count} logs saved successfully!`,
            icon: "success",
            confirmButtonColor: "#363740",
          }).then(function () {
            window.location.href = "/ManualLogs/FileUpload";
          });
        }, 1000)
    },
    error: function (response) {
      Swal.fire({
        title: "Error!",
        text: "Something went wrong!",
        icon: "error",
      });
      enableUploadBtn()
    },
  });
}

/**
 * Ajax call to save all logs into db.
 *
 * @param e: Target button
 */
function save(e) {
  e.preventDefault();
  const data = getData();
  console.log(data);

  $.ajax({
    url: "/ManualLogs/Save",
    type: "POST",
    data: JSON.stringify(data),
    contentType: "application/json; charset=utf-8",
    // data: {logs: data},
    success: function (response) {
      Swal.fire({
        title: "Success!",
        text: "Logs saved successfully!",
        icon: "success",
        confirmButtonColor: "#363740",
      }).then(function () {
        window.location.href = "/ManualLogs/FileUpload";
      });
    },
    error: function (response) {
      Swal.fire({
        title: "Error!",
        text: "Something went wrong!",
        icon: "error",
      });
    },
  });
}

/**
 * Retrieve values from each row in the table.
 *
 * @returns Array of objects containing the data.
 */
function getData() {
  let data = [];
  const $form = $("#fileUploadForm");
  const $rows = $form.find("div.log-div");
  const serialNumber = $("#deviceSerialNumber").val();
  const deviceType = $("#deviceType").val();

  $rows.each(function () {
    const energyUsage = $(this).find("input.energyUsage").val();
    const interval = $(this).find("input.interval").val();
    const loggedAt = $(this).find("input.loggedAt").val();

    data.push({
      DeviceType: deviceType,
      DeviceSerialNo: serialNumber,
      EnergyUsage: parseFloat(energyUsage),
      Interval: parseInt(interval),
      LoggedDate: loggedAt,
    });
  });
  return data;
}