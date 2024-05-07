import React from "react";
import { Link } from "react-router-dom";

function EmailResetPassword() {
  return (
    <div className="flex justify-center items-center bg-slate-50">
      <div className="grid grid-rows-1">
        <div className="flex flex-col bg-stone-100 p-[50px] gap-6">
          <div className="flex flex-row justify-around items-center">
            <div className="w-full">
              <h3 className="text-3xl font-light text-center">
                Forgot Password
              </h3>
            </div>
          </div>
          <form className="flex flex-col gap-4">
            <div className="font-medium text-sm">
              <label htmlFor="email">EMAIL</label>
              <input
                className="rounded-full bg-slate-100 w-full px-6 py-2 mt-2 text-sm font-normal"
                id="email"
                type="text"
                placeholder="Email"
              />
            </div>
            <Link to="/resetpassword">
              <button
                type="button"
                className="py-2 px-6 text-white bg-zinc-700 rounded-full"
              >
                Next
              </button>
            </Link>
          </form>
        </div>
      </div>
    </div>
  );
}

export default EmailResetPassword;
