import React from "react";
import { Outlet } from "react-router-dom";
import Footer from "../pages/Public/Footer";
import Header from "../pages/Public/Header";
import Navigation from "../pages/Public/Navigation";

export default function RootLayout() {
  return (
    <div className="container-xl flex flex-col gap-8">
      <Navigation />
      <Header />
      <main>
        <Outlet />
      </main>
      <Footer />
    </div>
  );
}
