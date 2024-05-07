import React from "react";
import { FaFacebook } from "react-icons/fa";
import { FaInstagramSquare } from "react-icons/fa";
import { FaLinkedin } from "react-icons/fa";
import Download_App from "../../assets/Download_App.png";
function Footer() {
  return (
    <footer className="flex flex-row justify-center">
      <div className="grid grid-cols-5 ">
        <div className="m-width-full">
          <div className="text-sm font-medium mb-4">CUSTOMER CARE</div>
          <ul>
            <li className="font-light text-sm text-stone-500">Help Center</li>
            <li className="font-light text-sm text-stone-500">
              InnerCode Blog
            </li>
            <li className="font-light text-sm text-stone-500">
              InnerCode Mall
            </li>
            <li className="font-light text-sm text-stone-500">
              Shopping Guide
            </li>
            <li className="font-light text-sm text-stone-500">Sales Guide</li>
            <li className="font-light text-sm text-stone-500">Pay</li>
            <li className="font-light text-sm text-stone-500">
              InnerCode Coin
            </li>
            <li className="font-light text-sm text-stone-500">Transport</li>
            <li className="font-light text-sm text-stone-500">
              Returns & Refunds
            </li>
            <li className="font-light text-sm text-stone-500">Customer Care</li>
            <li className="font-light text-sm text-stone-500">
              Warranty Policy
            </li>
          </ul>
        </div>
        <div className="">
          <div className="text-sm font-medium mb-4">ABOUT INNERCODE</div>
          <ul>
            <li className="font-light text-sm text-stone-500">
              Introduce InnerCode VietNam
            </li>
            <li className="font-light text-sm text-stone-500">Recruitment</li>
            <li className="font-light text-sm text-stone-500">
              InnerCode Terms
            </li>
            <li className="font-light text-sm text-stone-500">
              Privacy Policy
            </li>
            <li className="font-light text-sm text-stone-500">Genuine</li>
            <li className="font-light text-sm text-stone-500">
              Seller Channel
            </li>
            <li className="font-light text-sm text-stone-500">Falsh Sales</li>
            <li className="font-light text-sm text-stone-500">
              Shopee Affiliate Marketing Program
            </li>
            <li className="font-light text-sm text-stone-500">Media Contact</li>
          </ul>
        </div>
        <div className="">
          <div className="text-sm font-medium mb-4">PAY</div>
          <ul className="grid grid-cols-3 gap-1">
            <li className="font-light text-sm text-stone-500 max-w-[52px] max-h-[22px]">
              <img
                src="https://down-vn.img.susercontent.com/file/d4bbea4570b93bfd5fc652ca82a262a8"
                alt="logo"
              />
            </li>
            <li className="font-light text-sm text-stone-500 max-w-[52px] max-h-[22px]">
              <img
                src="https://down-vn.img.susercontent.com/file/a0a9062ebe19b45c1ae0506f16af5c16"
                alt="logo"
              />
            </li>
            <li className="font-light text-sm text-stone-500 max-w-[52px] max-h-[22px]">
              <img
                src="https://down-vn.img.susercontent.com/file/38fd98e55806c3b2e4535c4e4a6c4c08"
                alt="logo"
              />
            </li>
            <li className="font-light text-sm text-stone-500 max-w-[52px] max-h-[22px]">
              <img
                src="https://down-vn.img.susercontent.com/file/bc2a874caeee705449c164be385b796c"
                alt="logo"
              />
            </li>
            <li className="font-light text-sm text-stone-500 max-w-[52px] max-h-[22px]">
              <img
                src="https://down-vn.img.susercontent.com/file/2c46b83d84111ddc32cfd3b5995d9281"
                alt="logo"
              />
            </li>
          </ul>
        </div>
        <div className="">
          <div className="text-sm font-medium mb-4">FOLLOW US ON</div>
          <ul>
            <li>
              <a
                href="https://www.facebook.com/profile.php?id=61555617275150"
                target="_blank"
                rel="noopener noreferrer"
                className="flex flex-row justify-items-start gap-2"
              >
                <FaFacebook />
                <span className="font-light text-sm text-stone-500">
                  Facebook
                </span>
              </a>
            </li>
            <li>
              <a
                href="https://www.facebook.com/profile.php?id=61555617275150"
                target="_blank"
                rel="noopener noreferrer"
                className="flex flex-row justify-items-start gap-2"
              >
                <FaInstagramSquare />
                <span className="font-light text-sm text-stone-500">
                  Instagram
                </span>
              </a>
            </li>
            <li>
              <a
                href="https://www.facebook.com/profile.php?id=61555617275150"
                target="_blank"
                rel="noopener noreferrer"
                className="flex flex-row justify-items-start gap-2"
              >
                <FaLinkedin />

                <span className="font-light text-sm text-stone-500">
                  LinkediIn
                </span>
              </a>
            </li>
          </ul>
        </div>
        <div className="">
          <div className="text-sm font-medium mb-4">
            DOWNLOAD THE SHOPEE APP NOW
          </div>
          <div className="flex flex-cols justify-start gap-2">
            <img
              src={Download_App}
              alt="QR Code"
              className="w-[80px] h-[80px] "
            />
            <div className="flex flex-col gap-2 justify-center">
              <a
                href="https://www.facebook.com/profile.php?id=61555617275150"
                target="_blank"
                rel="noopener noreferrer"
              >
                <img
                  src="https://down-vn.img.susercontent.com/file/ad01628e90ddf248076685f73497c163"
                  alt="app"
                />
              </a>
              <a
                href="https://www.facebook.com/profile.php?id=61555617275150"
                target="_blank"
                rel="noopener noreferrer"
              >
                <img
                  src="https://down-vn.img.susercontent.com/file/ae7dced05f7243d0f3171f786e123def"
                  alt="app"
                />
              </a>
              <a
                href="https://www.facebook.com/profile.php?id=61555617275150"
                target="_blank"
                rel="noopener noreferrer"
              >
                <img
                  src="https://down-vn.img.susercontent.com/file/35352374f39bdd03b25e7b83542b2cb0"
                  alt="app"
                />
              </a>
            </div>
          </div>
        </div>
      </div>
    </footer>
  );
}

export default Footer;
