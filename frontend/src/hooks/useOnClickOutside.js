import { useEffect } from "react";



function useOnClickOutside(ref, handler) {
  useEffect(() => {
    const checkOutsideClick = (event) => {
      if (ref.current && !ref.current.contains(event.target)) {
        handler();
      }
    };

    document.addEventListener("click", checkOutsideClick);
    document.addEventListener("touchstart", checkOutsideClick);

    return () => {
      document.removeEventListener("click", checkOutsideClick);
      document.addEventListener("touchstart", checkOutsideClick);
    };
  }, [handler, ref]);
}



export default useOnClickOutside;