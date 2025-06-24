import { createBrowserRouter, RouterProvider } from "react-router-dom"
import Authorization from "./view/page/authorization/authorization"
import Registration from "./view/page/authorization/registration"
import CharacterCreate from "./view/page/character/character-create/character-create"
import CharacterSelect from "./view/page/character/character-select"
import RecoveryPassword from "./view/page/authorization/recoveryPassword"

const router = createBrowserRouter([
    { path: "/authorization", element: <Authorization /> },
    { path: "/registration", element: <Registration /> },
    { path: "/recovery-password", element: <RecoveryPassword/> },
    { path: "/character-create", element: <CharacterCreate /> },
    { path: "/character-select", element: <CharacterSelect /> }
])

export const App = () => {
    return <RouterProvider router={router} />
}