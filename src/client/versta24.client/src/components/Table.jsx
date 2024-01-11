import { useEffect, useState } from 'react';
import Header from "@/Components/Header.jsx";
import {Link} from "react-router-dom";


function Table() {
    const [orders, setOrders] = useState();

    useEffect(() => {
        getOrdersData();
    }, []);


    const contents = orders === undefined
        ? <p><em>загрузка...</em></p>
        : 
            <div className="container-fluid">
                <div className="col text-center">
                    <h2>Таблица заказов</h2>
                </div>
                <table className="table border">
                    <thead className="thead-dark">
                    <tr>
                        <th scope="col">Номер заказа</th>
                        <th scope="col">Город отправителя</th>
                        <th scope="col">Адрес отправителя</th>
                        <th scope="col">Город получателя</th>
                        <th scope="col">Адрес получателя</th>
                        <th scope="col">Вес груза</th>
                        <th scope="col">Дата забора груза</th>
                        <th scope="col"></th>
                    </tr>
                    </thead>
                    <tbody>
                    {orders.map(order =>
                        <tr key={order.id}>
                            <td>{order.id}</td>
                            <td>{order.senderCity}</td>
                            <td>{order.senderAddress}</td>
                            <td>{order.recipientCity}</td>
                            <td>{order.recipientAddress}</td>
                            <td>{order.cargoWeight}</td>
                            <td>{new Date(order.dateReceived).toLocaleDateString()}</td>
                            <td>
                                <Link to={`/order/${order.id}`}>
                                    <button className="btn btn-primary">Подробнее</button>
                                </Link>
                            </td>
                        </tr>
                    )}
                    </tbody>
                </table>
            </div>;
    return (
        <div>
            <Header/>
            
            {contents}
            
        </div>
    );

    async function getOrdersData() {
        const response = await fetch('order/getorders');

        console.log(response.url);

        const data = await response.json();
        console.log(data);
        setOrders(data);
    }
}

export default Table;