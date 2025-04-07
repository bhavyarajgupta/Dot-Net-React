import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { router } from "../Routers/Routes";

//delay simulation for 1 second
const sleep = (delay: number) => {
  return new Promise((resolve) => {
    setTimeout(resolve, delay);
  });
};

axios.defaults.baseURL = "http://localhost:5000/api/";

const responseBody = (response: AxiosResponse) => response.data;

// axios interceptor to add token to the header
axios.interceptors.response.use(
  async (response) => {
    await sleep(600); //delay simulation for 1 second
    return response;
  },
  (error: AxiosError) => {
    // console.log("causght by interceptor");
    if (error.response) {
      const { data, status } = error.response as AxiosResponse; // destructure the response object, and cast it to AxiosResponse
      // AxiosResponse is a generic type, so we need to cast it to AxiosResponse
      if (data) {
        switch (status) {
          case 400:
            if (data.errors) {
              const modelStateErrors: string[] = [];
              for (const key in data.errors) {
                if (data.errors[key]) {
                  modelStateErrors.push(data.errors[key]);
                }
              }

              throw modelStateErrors.flat(); // flat() method creates a new array with all sub-array
              // elements concatenated into it recursively up to the specified depth
            }
            toast.error(data.title);
            break;
          case 401:
            toast.error(data.title);
            break;
          case 402:
            toast.error(data.title);
            break;
          case 500:
            router.navigate("/server-error", { state: { error: data } }); // navigate to server error page , IT ADDS TO HISTORY STACK , SINCE WE ARE OUTSIDE OF THE REACT COMPONENT

            break;
          default:
            break;
        }
      } else {
        toast.error("An unexpected error occurred");
      }
    } else {
      toast.error("An unexpected error occurred");
    }
    return Promise.reject(error.response);
  }
);

const request = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
};

const Catalog = {
  list: () => request.get("products"),
  Details: (id: number) => request.get(`products/${id}`),
};

const testErrors = {
  get400Error: () => request.get("buggy/bad-request"),
  get401Error: () => request.get("buggy/unauthorised"),
  get404Error: () => request.get("buggy/not-found"),
  get500Error: () => request.get("buggy/server-error"),
  getValidationError: () => request.get("buggy/validation-error"),
};

const Basket = {
  get: () => request.get("basket"),
  addItem: (productId: number, quantity: 1) =>
    request.post(`basket?productId=${productId}&qty=${quantity}`, {}),
  removeItem: (productId: number, quantity: 1) =>
    request.delete(`basket?productId=${productId}&qty=${quantity}`),
};

const agent = {
  Catalog,
  testErrors,
};

export default agent;
