import { useState } from "react"
import { Link } from "react-router-dom";
import z from "zod";
import { callServer } from "../../../utils";

const alphaNumericRegex = /^[a-zA-Z0-9]+$/;

const AuthFormSchema = z.object({
    login: z
        .string()
        .min(6, 'Логин должен быть не меньше 6 символов')
        .max(64, 'Логин не может быть длиннее 64 символов')
        .regex(alphaNumericRegex, 'Только латинские буквы и цифры'),

    password: z
        .string()
        .min(6, 'Пароль должен быть не меньше 6 символов')
        .max(64, 'Пароль не может быть длиннее 64 символов')
        .regex(alphaNumericRegex, 'Только латинские буквы и цифры'),
})

type AuthFormValue = z.infer<typeof AuthFormSchema>;
export default function Authorization() {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');

    const handlerAuthorization = () => {
        try {
            const validatedData: AuthFormValue = AuthFormSchema.parse({
                login,
                password,
            });

            callServer("server:CreateAccount", validatedData.login, validatedData.password);
        } catch (error) {
            if (error instanceof z.ZodError) {
                console.error('Ошибки валидации:', error.errors);
            } else {
                console.error('Неизвестная ошибка:', error);
            }
        }
    };

    return (
        <div>
            <input type="text" value={ login } onChange={ e => setLogin(e.target.value) }></input>
            <input type="password" value={ password } onChange={ e => setPassword(e.target.value) }></input>
            <button onClick={handlerAuthorization}>Auth</button>
            <p><Link to="/recovery-password">recovery password</Link></p>
            <p><Link to="/registration">create account</Link></p>
        </div>
    )
}