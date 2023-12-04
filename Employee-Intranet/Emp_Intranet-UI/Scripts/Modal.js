
// Open the edit modal
function openEditModal() {
    document.getElementById('editModal').style.display = 'block';
    // You may pre-fill the input field with the current job title
    // document.getElementById('editJobTitle').value = '@Model.employee.employee_jobtitle';
}

// Close the edit modal
function closeEditModal() {
    document.getElementById('editModal').style.display = 'none';
}

// Save changes and close the modal
function saveJobTitleChanges() {
    var newJobTitle = document.getElementById('editJobTitle').value;
    // Implement logic to update the job title on the server using AJAX or other means
    // After saving changes, update the view if needed
    // For simplicity, we'll just update the displayed job title here
    document.getElementById('jobTitleDisplay').innerText = newJobTitle;
    closeEditModal();
}
