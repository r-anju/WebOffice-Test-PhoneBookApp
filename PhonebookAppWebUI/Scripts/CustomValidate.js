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

$('#forgotPassword').validate({
    errorClass: "text-danger",
    rules: {

        EmailAddress: {
            required: true,
            email: true,
        },
    },
    messages: {

        EmailAddress: {
            required: "Enter your email address",
            email: "Please enter a valid email address",
        },
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

$('#createContact').validate({
    errorClass: "text-danger",
    rules: {

        ContactName: {
            required: true,
        },
        EmailAddress: {
            required: true,
            email: true,
        },
        PhoneNumber: {
            required: true,

        }
    },
    messages: {
        ContactName: {
            required: "Please enter contact name",
        },
        EmailAddress: {
            required: "Enter your email address",
            email: "Please enter a valid email address",
        },
        PhoneNumber: {
            required: "Enter phone number",

        }
    }
});
$('#updateContact').validate({
    errorClass: "text-danger",
    rules: {

        ContactName: {
            required: true,
        },
        EmailAddress: {
            required: true,
            email: true,
        },
        PhoneNumber: {
            required: true,

        }
    },
    messages: {
        ContactName: {
            required: "Please enter contact name",
        },
        EmailAddress: {
            required: "Enter your email address",
            email: "Please enter a valid email address",
        },
        PhoneNumber: {
            required: "Enter phone number",

        }
    }
});
$('#verificationOTP').validate({
    errorClass: "text-danger",
    rules: {

        VerificationKey: {
            required: true,

        }
    },
    messages: {

        VerificationKey: {
            required: "Please enter verification code",

        }
    }
});
$('#resetPassword').validate({
    errorClass: "text-danger",
    rules: {
        Password: {
            required: true,

        },
        ConfirmPassword: {
            required: true,
            equalTo: '#password'
        }
    },
    messages: {
        Password: {
            required: "Enter a new password",

        },
        ConfirmPassword: {
            required: "Re enter password",
            equalTo: 'Passwords not matching'
        }
    }
});