
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Table from '@/Components/Table.jsx';
import InputModel from '@/Components/InputModel.jsx';
import './App.css';
import Order from "@/components/Order.jsx";

function App() {

    return (
        <div>

            <BrowserRouter>
                <Routes>
                    <Route path="/createOrder" element={<InputModel/>}/>
                    <Route path="/" element={<Table/>}/>
                    <Route path="/order/:id" element={<Order/>}/>
                </Routes>
            </BrowserRouter>
            
        </div>
    );

}

export default App;