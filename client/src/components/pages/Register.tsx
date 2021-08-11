import { Dispatch, FC, FormEvent, Fragment, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { signInAction } from "../../redux/actions/userActions";
import { ApplicationSate } from "../../redux/store";
import { SignUpState } from "../../redux/types/types";
import { RegisterForm } from "../RegisterForm";

interface RegisterProps {}

export const Register: FC<RegisterProps> = ({}) => {
    const [emailReg, setEmailReg] = useState("");
    const [firstNameReg, setFirstNameReg] = useState("");
    const [lastNameReg, setLastNameReg] = useState("");
    const [passwordReg, setPasswordReg] = useState("");
    const [confirmPasswordReg, setConfirmPasswordReg] = useState("");
    const [roleReg, setRoleReg] = useState("user");

    const dispatch: Dispatch<any> = useDispatch();

    const userRegisterResponse: SignUpState = useSelector(
        (state: ApplicationSate) => {
            return state.signup;
        }
    );

    const { loading, error, data } = userRegisterResponse;

    const registerUser = () => {
        dispatch(
            signInAction(
                emailReg,
                firstNameReg,
                lastNameReg,
                passwordReg,
                confirmPasswordReg,
                roleReg
            )
        );
    };

    const registerHandler = (e: FormEvent<HTMLElement>) => {
        e.preventDefault();
        registerUser();
    };
    return (
        <>
            <RegisterForm
                setEmailReg={setEmailReg}
                setFirstNameReg={setFirstNameReg}
                setLastNameReg={setLastNameReg}
                setPasswordReg={setPasswordReg}
                setConfirmPasswordReg={setConfirmPasswordReg}
                setRoleReg={setRoleReg}
                registerHandler={registerHandler}
                userRegResponse={userRegisterResponse}
            />
            {error.data}
        </>
    );
};
