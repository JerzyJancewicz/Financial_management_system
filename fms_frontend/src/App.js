import './App.css';
import { BrowserRouter as Router, Route, Switch, Routes } from "react-router-dom";
import Main from './Components/Main';
import Budget from './Components/Budget';
import NewTransaction from './Components/NewTransaction';
import Transaction from './Components/Transaction';
import TransactionCreated from './Components/TransactionCreated';

function App() {
  return (
    <div className='container'>
    <Router>
      <Routes>
        <Route path="/" element={<Main />} />
        <Route path="/budget/:Id" element={<Budget />} />
        <Route path="/NewTransaction" element={<NewTransaction />} />
        <Route path="/transaction/:Id" element={<Transaction />} />
        <Route path="/transactionCreated" element={<TransactionCreated />} />
      </Routes>
    </Router>
  </div>
  );
}

export default App;
