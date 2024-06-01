// User Registration Validation

$('#registerUser').validate({
    errorClass: "text-danger",
    rules: {
        NickName: {
            required: true,

        },
        EmailAddress: {
            required: true,
            email: true,
        },
        Password: {
            required: true,

        },
        ConfirmPassword: {
            required: true,
            equalTo: '#password'
        }
    },
    messages: {
        NickName: {
            required: "Enter your name",

        },
        EmailAddress: {
            required: "Enter your email address",
            email: "Please enter a valid email address",
        },
        Password: {
            required: "Enter a new password",

        },
        ConfirmPassword: {
            required: "Re enter password",
            equalTo: 'Passwords not matching'
        }
    }
});

$('#loginForm').validate({
    errorClass: "text-danger",
    rules: {

        EmailAddress: {
            required: true,
            email: true,
        },
        Password: {
            required: true,

        }
    },
    messages: {

        EmailAddress: {
            required: "Enter your email address",
            email: "Please enter a valid email address",
        },
        Password: {
            required: "Enter a new password",

        }
    }
});