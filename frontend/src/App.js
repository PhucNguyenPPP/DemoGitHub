// import { Routes, Route } from "react-router-dom";
// import { Home, Login } from "./pages/Public";
// import path from "./routes";
// import Signup from "./pages/Public/Signup";
// function App() {
//   return (
//     <>
//       <Routes>
//         <Route path={path.LOGIN} element={<Login />}></Route>
//         <Route path={path.HOME} element={<Home />}></Route>
//         <Route path={path.SIGNUP} element={<Signup />}></Route>
//       </Routes>
//     </>
//   );

import { RouterProvider } from "react-router-dom";
import { router } from "./routes/index";
export default function App() {
  return <RouterProvider router={router} />;
}
