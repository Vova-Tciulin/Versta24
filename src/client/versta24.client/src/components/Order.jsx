import React, { useEffect, useState } from 'react';
import {useLocation, useParams} from 'react-router-dom';
import Header from "@/Components/Header.jsx";

export default function Order() {
    const { id } = useParams();
    
    const [order, setOrder] = useState();

    useEffect(() => {
        getOrderData();
    }, []); // Пустой массив зависимостей означает, что useEffect будет выполнен только при первом рендере

    async function getOrderData() {
        
        const response = await fetch(`/order/getorderbyid?orderId=${id}`);
        if (response.ok){
            const data = await response.json();
            setOrder(data);
        }
        else
        {
            const error= response.text();
            alert(error);
        }
        
    }

    return (
        <div>
            <Header />
            <div className="container">
                <div className="col-md-6 border rounded-3 offset-3 text-start py-2">
                    <div className="col p-2 text-center border-bottom">
                        <h3>Информация о заказе</h3>
                    </div>
                    {order && order.id?(
                        <>
                            <div className="col px-2 pt-1 border-bottom">
                                <h5 className="text-info-emphasis">Номер заказа: <span className="text-black">{order.id}</span></h5>
                            </div>
                            <div className="col px-2 border-bottom">
                                <h5 className="text-info-emphasis">Город отправителя: <span className="text-black">{order.senderCity}</span></h5>
                            </div>
                            <div className="col px-2 border-bottom">
                                <h5 className="text-info-emphasis">Адрес отправителя: <span className="text-black">{order.senderAddress}</span></h5>
                            </div>
                            <div className="col px-2 border-bottom">
                                <h5 className="text-info-emphasis">Город получателя: <span className="text-black">{order.recipientCity}</span></h5>
                            </div>
                            <div className="col px-2 border-bottom">
                                <h5 className="text-info-emphasis">Адрес получателя: <span className="text-black">{order.recipientAddress}</span></h5>
                            </div>
                            <div className="col px-2 border-bottom">
                                <h5 className="text-info-emphasis">Вес груза: <span className="text-black">{order.cargoWeight}</span></h5>
                            </div>
                            <div className="col px-2">
                                <h5 className="text-info-emphasis">Дата забора груза: <span className="text-black">{new Date(order.dateReceived).toLocaleDateString()}</span></h5>
                            </div>
                        </>
                    ):(<p>Загрузка данных о заказе</p>)
                    }
                    
                </div>
            </div>
        </div>
    );
}
