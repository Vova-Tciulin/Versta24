import { useEffect, useState } from 'react';
import Header from "@/Components/Header.jsx";
import 'bootstrap/dist/css/bootstrap.min.css';
import {useNavigate} from "react-router-dom";

export default function InputModel(){
    const navigate = useNavigate();
    const [senderCity, setSenderCity] = useState('');
    const [senderAddress, setSenderAddress] = useState('');
    const [recipientCity, setRecipientCity] = useState('');
    const [recipientAddress, setRecipientAddress] = useState('');
    const [cargoWeight, setCargoWeight] = useState('');
    const [dateReceived, setDateReceived] = useState('');
    const [errors, setErrors] = useState({});
    async function handleSubmit() {
        
        const inputFields = { senderCity, senderAddress, recipientCity, recipientAddress, cargoWeight, dateReceived };
        const inputErrors = {};
        Object.keys(inputFields).forEach((key) => {
            if (!inputFields[key]) {
                inputErrors[key] = 'Это поле обязательно для заполнения';
            }
        });

        const currentDate = new Date();
        const selectedDate = new Date(dateReceived);

        if (selectedDate < currentDate) {
            setErrors({ dateReceived: 'Выберите дату не меньше текущей' });
            return;
        }

        
        if (cargoWeight && isNaN(parseFloat(cargoWeight))) {
            inputErrors.cargoWeight = 'Введите корректный вес груза';
        }

        
        if (Object.keys(inputErrors).length > 0) {
            setErrors(inputErrors);
            return;
        }
        
        setErrors({});
        
        const response = await fetch('order/create', {
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            method: 'POST',
            body: JSON.stringify(inputFields)
        });

        if (response.ok) {
            navigate('/');
        } else {
            const error = await response.text();
            alert('Ошибка при создании заказа:' + error);
            console.error('Ошибка при создании заказа:', error);
        }
        
    }
    
    return(
        <>
            <Header/>
            <div className="container">
                <div className="col-md-4 p-2 offset-4 border rounded-4">
                    <div className="col text-center">
                        <h3>Создание заказа</h3>
                    </div>   
                    <div className="col p-1">
                        <input
                            className="form-control"
                            placeholder="Город отправителя"
                            required
                            value={senderCity}
                            onChange={event=>setSenderCity(event.target.value)}
                        />
                        {errors.senderCity && <p className="text-danger m-0">{errors.senderCity}</p>}
                    </div>
                    <div className="col p-1">
                        <input
                            className="form-control"
                            placeholder="Адрес отправителя"
                            required
                            value={senderAddress}
                            onChange={event=>setSenderAddress(event.target.value)}
                        />
                        {errors.senderAddress && <p className="text-danger m-0">{errors.senderAddress}</p>}
                    </div>
                    <div className="col p-1">
                        <input
                            className="form-control"
                            placeholder="Город получателя"
                            value={recipientCity}
                            onChange={event=>setRecipientCity(event.target.value)}
                        />
                        {errors.recipientCity && <p className="text-danger m-0">{errors.recipientCity}</p>}
                    </div>
                    <div className="col p-1">
                        <input
                            className="form-control"
                            placeholder="Адрес получателя"
                            value={recipientAddress}
                            onChange={event=>setRecipientAddress(event.target.value)}
                        />
                        {errors.recipientAddress && <p className="text-danger m-0">{errors.recipientAddress}</p>}
                    </div>
                    <div className="col p-1">
                        <input
                            className="form-control"
                            type="number"
                            step="0.01"
                            placeholder="Вес груза"
                            value={cargoWeight}
                            onChange={event=>setCargoWeight(event.target.value)}
                        />
                        {errors.recipientAddress && <p className="text-danger m-0">{errors.recipientAddress}</p>}
                    </div>
                    <div className="col p-1">
                        <input
                            className="form-control"
                            placeholder="Дата забора груза"
                            type="date"
                            value={dateReceived}
                            onChange={event=>setDateReceived(event.target.value)}
                        />
                        {errors.dateReceived && <p className="text-danger m-0">{errors.dateReceived}</p>}
                    </div>
                    <div className="col p-1"> 
                        <button className="btn btn-primary" type='submit' onClick={()=>handleSubmit()}>Создать заявку</button>
                    </div>
                </div>
            </div>

        </>
    )
}