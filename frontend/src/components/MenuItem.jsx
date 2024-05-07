import { Link } from "react-router-dom";
import SearchInput from "./SearchInput";
import { MdOutlineShoppingCart } from "react-icons/md";
import { ProductCategory } from "./ProductCategory";

export default function MenuItem() {
  return (
    <div className="flex items-center justify-center mt-2 gap-6">
      <ProductCategory />
      <SearchInput />
      <div>
        <Link to="cart">
          <span className="flex items-center">
            <MdOutlineShoppingCart size={25} />
          </span>
        </Link>
      </div>
    </div>
  );
}
