import React from "react";
import { CiFacebook } from "react-icons/ci";
import { FcGoogle } from "react-icons/fc";
import { useNavigate } from "react-router-dom";
function Signup() {
  const navigate = useNavigate();
  const handleLogin = () => {
    navigate("/login");
  };
  return (
    <div className="flex justify-center items-center bg-slate-50">
      <div className="grid grid-rows-1">
        <div className="grid grid-cols-2">
          <div className="flex flex-col bg-stone-100 p-[50px] gap-6">
            <div className="flex flex-row justify-around items-center">
              <div className="w-full">
                <h3 className="text-3xl font-light">Sign Up</h3>
              </div>
              <div className="flex flex-row justfify-center items-center gap-4">
                <a
                  href="https://www.facebook.com/profile.php?id=61555617275150"
                  target="blank"
                  rel="noopener noreferrer"
                >
                  <FcGoogle className="w-6 h-6" />
                </a>
                <a
                  href="https://www.facebook.com/profile.php?id=61555617275150"
                  target="blank"
                  rel="noopener noreferrer"
                >
                  {/* <img
                    width="52"
                    height="52"
                    src="https://img.icons8.com/color/48/facebook-new.png"
                    alt="facebook-new"
                  /> */}
                  <CiFacebook className="w-6 h-6" />
                </a>
              </div>
            </div>
            <form className="flex flex-col gap-4">
              <div className="font-medium text-sm">
                <label htmlFor="username">USERNAME</label>
                <input
                  className="rounded-full bg-slate-100 w-full px-6 py-2 mt-2 text-sm font-normal"
                  id="username"
                  type="text"
                  placeholder="Username"
                />
              </div>
              <div className="font-medium text-sm">
                <label htmlFor="password">PASSWORD</label>
                <input
                  className="rounded-full bg-slate-100 w-full px-6 py-2 mt-3 text-sm font-normal"
                  id="password"
                  type="password"
                  placeholder="Password"
                />
              </div>
              <div className="font-medium text-sm">
                <label htmlFor="confirm_password">CONFIRM PASSWORD</label>
                <input
                  className="rounded-full bg-slate-100 w-full px-6 py-2 mt-3 text-sm font-normal"
                  id="confirm_password"
                  type="password"
                  placeholder="Confirm Password"
                />
              </div>
              <button
                type="button"
                className="py-2 px-6 text-white bg-zinc-700 rounded-full"
              >
                Sign Up
              </button>
              <div className="flex justify-between">
                <label class="inline-flex items-center" for="redCheckBox">
                  <input
                    id="redCheckBox"
                    type="checkbox"
                    class="w-4 h-4 accent-red-400"
                  />
                  <span class="ml-2">
                    I have read and agree to the
                    <a
                      href="https://www.facebook.com/profile.php?id=61555617275150"
                      target="_blank"
                      rel="noopener noreferrer"
                      className="text-blue-600 ml-1"
                    >
                      Terms Of Service
                    </a>
                  </span>
                </label>

                {/* <small className="flex justify-center items-center text-gray-500">
                  <a
                    href="https://www.facebook.com/profile.php?id=61555617275150"
                    target="blank"
                    rel="noopener noreferrer"
                  >
                    Forgot Password
                  </a>
                </small> */}
              </div>
            </form>
          </div>

          <div className="flex flex-col justify-center items-center bg-zinc-700 text-[#fff] p-[50px]">
            <div className="flex flex-col justify-center items-center gap-2 w-full">
              <h2 className="font-bold text-4xl">Welcome to signup</h2>
              <p>Already have an account?</p>
              <button
                onClick={() => handleLogin()}
                type="button"
                className="border border-1 px-6 py-2 rounded-full"
              >
                Log In
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Signup;
