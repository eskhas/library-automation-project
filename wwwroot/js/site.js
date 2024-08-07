// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {
    $('#createAuthorForm').on('submit', function(e) {
        e.preventDefault();
        
        var formData = $(this).serialize();

        $.ajax({
            type: 'POST',
            url: '/Author/CreateFromBook',
            data: formData,
            success: function(result) {
                $('#createAuthorModal').modal('hide');
                $('#createAuthorForm')[0].reset();
                $('#Book_AuthorId').append('<option value="' + result.id + '">' + result.fullName + '</option>');
                $('#Book_AuthorId').val(result.id).change();
            },
            error: function(xhr, status, error) {
                alert('An error occurred while creating the author: ' + error);
            }
        });
    });
});
