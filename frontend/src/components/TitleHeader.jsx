import { Link } from "react-router-dom";

export default function TitleHeader() {
  return (
    <div className="w-full flex justify-center">
      <Link to="/">
        <p className="text-3xl font-bold">InnerShop</p>
      </Link>
    </div>
  );
}
