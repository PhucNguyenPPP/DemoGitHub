import React, { useState } from "react";
import Logo from "../assets/Sentinels_Logo.png";
import { NavLink } from "react-router-dom";
import { FaTimes } from "react-icons/fa";
import { CiMenuFries } from "react-icons/ci";

function Navbar() {
  const [menuClick, setMenuClick] = useState(false);
  const handleClick = () => setMenuClick(!menuClick);
  const content = (
    <>
      <div className="lg:hidden block absolute top-14 w-full left-0 right-0 bg-slate-900 transition z-10">
        <ul className="text-center text-x1 p-4">
          <NavLink>
            <li className="my-4 py-4 border-b border-slate-800 hover:bg-slate-800 hover:rounded">
              Home
            </li>
          </NavLink>
          <NavLink>
            <li className="my-4 py-4 border-b border-slate-800 hover:bg-slate-800 hover:rounded">
              About
            </li>
          </NavLink>
          <div>
            <li className="my-4 py-4 border-b border-slate-800 hover:bg-slate-800 hover:rounded">
              <div role="button">Notification</div>
            </li>
          </div>
          <NavLink to="/Login">
            <li className="my-4 py-4 border-b border-slate-800 hover:bg-slate-800 hover:rounded">
              Login
            </li>
          </NavLink>
        </ul>
      </div>
    </>
  );

  return (
    <nav className="navbar h-14">
      <div className="h-20 flex justify-between z-50 text-white lg:py-5 px-14 py-4 flex-1">
        <div className="flex items-center flex-1 mb-6">
          <img src={Logo} alt="" className="text-3x1 size-20" />
        </div>
        <div className="lg:flex sm:flex items-center justify-end font-normal hidden">
          <div className="flex-initial">
            <ul className="flex gap-8 mr-5 mb-6 text-[18px] text-center">
              <NavLink>
                <li className="hover:text-fuchsia-600 transition border-b-2 border-slate-900 hover:border-fuchsia-600 cursor-pointer">
                  Home
                </li>
              </NavLink>
              <NavLink>
                <li className="hover:text-fuchsia-600 transition border-b-2 border-slate-900 hover:border-fuchsia-600 cursor-pointer">
                  About
                </li>
              </NavLink>
              <div>
                <li className="hover:text-fuchsia-600 transition border-b-2 border-slate-900 hover:border-fuchsia-600 cursor-pointer">
                  <div role="button">Notification</div>
                </li>
              </div>

              <NavLink to="/Login">
                <li className="hover:text-fuchsia-600 transition border-b-2 border-slate-900 hover:border-fuchsia-600 cursor-pointer">
                  Login
                </li>
              </NavLink>
            </ul>
          </div>
        </div>
        <div>{menuClick && content}</div>
        <button
          className="block sm:hidden transtion mb-5"
          onClick={handleClick}
        >
          {menuClick ? <FaTimes /> : <CiMenuFries />}
        </button>
      </div>
    </nav>
  );
}

export default Navbar;
