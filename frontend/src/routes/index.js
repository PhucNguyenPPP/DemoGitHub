import { createBrowserRouter } from "react-router-dom";
import RootLayout from "../Layout";
import CartPage from "../pages/Public/Cart";
import ErrorPage from "../pages/Public/Error";
import HomePage from "../pages/Public/Home";
import Login from "../pages/Public/Login";
import Signup from "../pages/Public/Signup";
import ForgotPassword from "../pages/Public/ForgotPassword";
import ResetPassword from "../pages/Public/ResetPassword";
export const router = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout />,
    errorElement: <ErrorPage />,
    children: [
      { index: true, element: <HomePage /> },
      { path: "cart", element: <CartPage /> },
      { path: "login", element: <Login /> },
      { path: "signup", element: <Signup /> },
      { path: "forgotpassword", element: <ForgotPassword /> },
      { path: "resetpassword", element: <ResetPassword /> },
    ],
  },
]);
