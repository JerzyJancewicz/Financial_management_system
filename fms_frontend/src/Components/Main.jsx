import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

function Main()
{
    const[budgetData, setBudgetData] = useState([]);

    const navigate = useNavigate();
    const handleGet = () => {
        fetch(`/api/Fms`)
            .then((res) => {
                return res.json();
            })
            .then((data) => {
                const dataWithIds = data.map((item, index) => ({
                    ...item,
                    id: index + 1,
                }));
                console.log(dataWithIds)
                setBudgetData(dataWithIds);
            })
            .catch(error =>{
                console.log(error);
            });
    }

    useEffect(() => {
        handleGet();
    },[1])

    const handleClick = (Id) => {
        navigate(`/budget/${Id}`)
    };

    return (
    <div>
        <h1>System Zarządzania Finansami</h1>
        <h2>Użytkownik: Jerzy Jancewicz</h2>
        <h2 className="h2-main">Rola: Księgowy</h2>
        <div id="budget-list">
            <h2>Przypisane budżety</h2>
            <ul>
                {Array.isArray(budgetData) ? (
                    budgetData.map((data) => (
                        <li>
                            <button onClick={() => handleClick(data.id)}>
                                <strong>{data.name}</strong>
                                <p>Nazwa Projektu: {data.projectName}</p>
                                <p>Kwota: {data.balance}</p>
                            </button>
                        </li>
                    ))
                ) : (
                    <div>No Budgets available</div>
                )}
            </ul>
        </div>        
    </div>);
}

export default Main;