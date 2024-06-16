import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

function NewTransaction() {
    const { Id } = useParams();
    const navigate = useNavigate();
    const [budgetDetail, setBudgetDetail] = useState(null);
    const [transactionType, setTransactionType] = useState("WPŁATA");
    const [transactionAmount, setTransactionAmount] = useState("");

    useEffect(() => {
        fetch(`/api/Fms/budget/${Id}`)
            .then((res) => res.json())
            .then((data) => {
                setBudgetDetail(data);
            })
            .catch((error) => console.log(error));
    }, [Id]);

    const goBack = () => {
        
    };

    const handleTransactionTypeChange = (e) => {
        setTransactionType(e.target.value);
    };

    const handleTransactionAmountChange = (e) => {
        setTransactionAmount(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        
        const formData = {
            transactionType: transactionType,
            transactionAmount: parseFloat(transactionAmount),
        };

        fetch(`/api/Fms/addTransaction/${1}/${1}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(formData)
        })
        .then((res) => {
            if (res.ok) {
                navigate(`/transactionCreated`);
            } else {
                throw new Error("Failed to add transaction");
            }
        })
        .catch((error) => console.log(error));
    };

    const handleSaveAsDraft = () => {
        console.log("Save as draft clicked");
    };

    if (!budgetDetail) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <div id="transaction-form">
                <button className="back-button" onClick={goBack}>Wstecz</button>
                <h2>Nowa transakcja</h2>
                <form id="transactionForm" onSubmit={handleSubmit}>
                    <label htmlFor="transactionType">Typ transakcji:</label>
                    <select
                        id="transactionType"
                        name="transactionType"
                        value={transactionType}
                        onChange={handleTransactionTypeChange}
                        required
                    >
                        <option value="WPŁATA">Wpłata</option>
                        <option value="WYPŁATA">Wypłata</option>
                    </select>
                    <label htmlFor="transactionAmount">Kwota:</label>
                    <input
                        type="number"
                        id="transactionAmount"
                        name="transactionAmount"
                        step="0.01"
                        value={transactionAmount}
                        onChange={handleTransactionAmountChange}
                        required
                    />
                    <button type="submit">Wykonaj</button>
                    <button type="button" onClick={handleSaveAsDraft}>Dodaj jako wersja robocza</button>
                </form>
            </div>
        </div>
    );
}

export default NewTransaction;
