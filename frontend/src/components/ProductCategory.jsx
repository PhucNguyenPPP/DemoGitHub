import { useEffect, useRef, useState } from "react";
import { CgDetailsMore } from "react-icons/cg";

export function ProductCategory() {
  const [isOpen, setIsOpen] = useState(false);
  const dropdownRef = useRef(null);

  const toggleModal = () => {
    setIsOpen(!isOpen);
  };

  const handleClickOutside = (event) => {
    if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
      setIsOpen(false);
    }
  };

  useEffect(() => {
    document.addEventListener("click", handleClickOutside, true);
    return () => {
      document.removeEventListener("click", handleClickOutside, true);
    };
  }, []);

  return (
    <div
      ref={dropdownRef}
      className="relative md:w-[8rem] sm:w-[7rem] px-2 py-2 h-full bg-slate-500 rounded-xl"
    >
      <button
        className="flex flex-row gap-2 items-center justify-center"
        onClick={toggleModal}
      >
        <span className="md:text-3xl sm:text-base">
          <CgDetailsMore color="white" />
        </span>
        <span className="text-white font-bold sm:text-[16px]">Category</span>
      </button>
      {isOpen && (
        <div className="absolute left-0 mt-3 w-full bg-white rounded-lg shadow-lg">
          <ul className="py-2">
            <li className="px-4 py-2 hover:bg-gray-200 cursor-pointer">
              Category 1
            </li>
            <li className="px-4 py-2 hover:bg-gray-200 cursor-pointer">
              Category 2
            </li>
            <li className="px-4 py-2 hover:bg-gray-200 cursor-pointer">
              Category 3
            </li>
          </ul>
        </div>
      )}
    </div>
  );
}
