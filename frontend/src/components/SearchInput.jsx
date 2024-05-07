import { FaSearch } from "react-icons/fa";

export default function SearchInput() {
  return (
    <form className="max-w-xl lg:w-[40rem] sm:w-[28rem]">
      <label
        htmlFor="default-search"
        className="mb-2 text-sm font-medium text-gray-900 sr-only"
      >
        Search
      </label>
      <div className="relative">
        <div className="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
          <FaSearch />
        </div>
        <input
          type="search"
          id="default-search"
          className="block w-full p-4 ps-10 md:text-base sm:text-sm text-gray-900 border border-gray-300 rounded-lg focus:outline-none bg-gray-50 focus:border-black focus:border-1"
          placeholder="Search product, category..."
          maxLength="50"
          required
        />
        <button
          type="submit"
          className="text-white absolute end-2.5 bottom-2.5 bg-gray-700 hover:bg-gray-800 focus:ring-4 focus:outline-none focus:ring-gray-300 font-medium rounded-lg md:text-base sm:text-sm px-4 py-2"
        >
          Search
        </button>
      </div>
    </form>
  );
}
