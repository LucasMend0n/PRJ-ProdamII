import CadastroEstabelecimento from './Telas/CadastroEstabelecimento'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import ListaEstabelecimentos from './Telas/ListaEstabelecimentos';

function App() {

  return (
    <Router>
      <Routes>
        <Route path="/" element={<CadastroEstabelecimento />}></Route>
        <Route path="/registros" element={<ListaEstabelecimentos />}></Route>
      </Routes>
    </Router>
  )
}

export default App
