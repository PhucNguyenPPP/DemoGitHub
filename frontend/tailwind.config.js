/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js,jsx,ts,tsx}", "./public/index.html"],
  theme: {
    extend: {
      cursor: {
        pointer: "pointer",
      }, //click vo thanh con tro
    },
  },
  plugins: [],
};
