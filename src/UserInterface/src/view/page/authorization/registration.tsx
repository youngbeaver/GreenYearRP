import { useState } from "react";
import { Link } from "react-router-dom";
import z from "zod";
import { callServer } from "../../../utils";

const alphaNumericRegex = /^[a-zA-Z0-9]+$/;

const RegistrationFormSchema = z.object({
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

    confirmPassword: z.string(),
})
    .refine(
        (data) => data.password === data.confirmPassword,
        {
            message: 'Пароли не совпадают',
            path: ['confirmPassword'],
        }
    );

type RegistrationFormValue = z.infer<typeof RegistrationFormSchema>;

export default function Registration() {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const [passwordRepeat, setPasswordRepeat] = useState('');

    const handlerRegistration = () => {
        try {
            const validatedData: RegistrationFormValue = RegistrationFormSchema.parse({
                login,
                password,
                confirmPassword: passwordRepeat,
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
            <input type='text' value={login} onChange={e => setLogin(e.target.value)} placeholder="Логин" />
            <input type='password' value={password} onChange={e => setPassword(e.target.value)} placeholder="Пароль" />
            <input type='password' value={passwordRepeat} onChange={e => setPasswordRepeat(e.target.value)} placeholder="Подтвердите пароль" />
            <button onClick={handlerRegistration}>Создать аккаунт</button>
            <p><Link to="/authorization">Войти</Link></p>
        </div>
    );
}