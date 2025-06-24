import { useState } from "react"
import { Link } from "react-router-dom";

export default function RecoveryPassword() {
    const [email, setEmail] = useState('');

    return (
        <div>
            <input type="email" value={email} onChange={e => setEmail(e.target.value)}></input>
            <button>Send Code for recovery</button>
            <p><Link to="/authorization">Авторизация</Link></p>
        </div>
    )
}