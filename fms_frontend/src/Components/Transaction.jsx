import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";

function Transaction()
{
    const navigate = useNavigate();
    const { Id } = useParams();

    const [transactionDetail, setTransactionDetail] = useState(null);

    useEffect(() => {
        fetch(`/api/Fms/transaction/${Id}`)
          .then((res) => res.json())
          .then((data) => 
            {
                setTransactionDetail(data);
            })
          .catch((error) => console.log(error));
      }, [Id]);


    if (!transactionDetail) {
        return <div>Loading...</div>;
    }

    const goBack = () => {
        console.log(Id)
        navigate(`/budget/${Id}`);
    };

    return (
    <div>        
        <div id="transaction-details">
            <button class="back-button" onclick={goBack}>Wstecz</button>
            <h2>Szczegóły transakcji</h2>
            <p><strong>Data operacji: {transactionDetail.operationDate}</strong> <span id="transactionDate"></span></p>
            <p><strong>Kwota: {transactionDetail.amount}</strong> <span id="transactionAmountDetail"></span> zł</p>
            <p><strong>Rodzaj transakcji: {transactionDetail.transactionTypes}</strong> <span id="transactionTypeDetail"></span></p>
            <p><strong>Status: {transactionDetail.statusTypes}</strong> <span id="transactionStatus"></span></p>
            <p><strong>Użytkownik: </strong> <span id="transactionUser">
                <ul>
                    <li>Imię: {transactionDetail.name}</li>
                    <li>Nazwisko: {transactionDetail.surname}</li>
                    <li>Numer Telefonu: {transactionDetail.phoneNumber}</li>
                    <li>Email: {transactionDetail.email}</li>
                    <li>Nazwa użytkownika: {transactionDetail.nickname}</li>
                </ul>
            </span></p>
            <ul id="transactionUsersList" class="details-list">
            </ul>
        </div>    
    </div>)
}

export default Transaction;