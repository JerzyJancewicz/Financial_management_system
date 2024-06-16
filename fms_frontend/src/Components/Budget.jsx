import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";

function Budget()
{
    const navigate = useNavigate();
    const { Id } = useParams();
    const [budgetDetail, setBudgetDetail] = useState(null);

    useEffect(() => {
        fetch(`/api/Fms/budget/${Id}`)
          .then((res) => res.json())
          .then((data) => 
            {
                setBudgetDetail(data);
            })
          .catch((error) => console.log(error));
      }, [5]);


    if (!budgetDetail) {
        return <div>Loading...</div>;
    }

    const goBack = () => {
        navigate('/');
    };

    const handleDetails = (id) => {
        navigate(`/transaction/${id}`)
    }
    const handleAdd = () => {
        navigate(`/NewTransaction`)
    }

    return (
    <div>
        <div id="budget-details">
            <button class="back-button" onClick={goBack}>Wstecz</button>
            <h2>Szczegóły budżetu</h2>
            <p><strong>Nazwa: {budgetDetail.name}</strong> <span id="budgetName"></span></p>
            <p><strong>Nazwa projektu: {budgetDetail.projectName}</strong> <span id="projectName"></span></p>
            <p><strong>Kwota:</strong> <span id="budgetAmount">{budgetDetail.balance}</span> zł</p>
            <p><strong>Opis:</strong> <span id="budgetDescription">{budgetDetail.description}</span></p>
            <ul>
                <p><strong>Transakcje:</strong>                        {console.log(budgetDetail)}
                </p>
                {Array.isArray(budgetDetail.transactions) ? (
                    budgetDetail.transactions.map((data, index) => (
                        <div className="cos" onClick ={() =>handleDetails(index + 1)}>
                            <ul id="transactionsList">
                                <div class="details-list-div">
                                    <li>Data: {data.operationDate}</li>
                                    <li>Kwota: {data.amount}</li>
                                    <li>Typ: {data.transactionTypes}</li>
                                    <li>Status: {data.statusTypes}</li>                                
                                </div>
                            </ul>
                        </div>
                    ))
                ) : (
                    <div>No Transaction details available</div>
                )}
            </ul>    

            <p><strong>Konta bankowe:</strong></p>
            <ul id="bankAccountsList" class="details-list">
                {Array.isArray(budgetDetail.bankAccounts) ? (
                    budgetDetail.bankAccounts.map((data) => (
                        <ul id="transactionsList">
                            <div class="details-list-div">
                                <li>Nazwa Banku: {data.bankName}</li>
                                <li>Saldo: {data.balance}</li>
                                <li>Numer Konta: {data.accountNumber}</li>
                            </div>
                        </ul>
                    ))
                ) : (
                    <div>No Transaction details available</div>
                )}
            </ul>       
            <button onClick={()=>handleAdd()}>Dokonaj transakcji</button>
        </div>  
    </div>)
}

export default Budget;