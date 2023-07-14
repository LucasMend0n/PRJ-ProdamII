import { useState } from 'react';
import './cadastro.css'
import { Link } from 'react-router-dom';
import baseApi from '../../api';

const CadastroEstabelecimento = () => {
    const [nomeEmpresa, setNomeEmpresa] = useState('');
    const [cep, setCep] = useState('');
    const [cnpj, setCnpj] = useState('');
    const [tipoEstabelecimento, setTipoEstabelecimento] = useState('');
    const [mensagem, setMensagem] = useState('');
    const [sucesso, setSucesso] = useState(false);

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await baseApi.post('/Estabelecimentos', {
                nomeEmpresa,
                cep,
                cnpj,
                tipoEstabelecimento
            });

            console.log(response.data);

            setNomeEmpresa('');
            setCep('');
            setCnpj('');
            setTipoEstabelecimento('');
            setMensagem('Cadastro realizado com sucesso!');
            setSucesso(true);
        } catch (error) {
            setMensagem('Ocorreu um erro ao cadastrar o estabelecimento.');
            setSucesso(false);
        }
    };

    return (
        <div className="container">
            <h1>Cadastro de Estabelecimento</h1>
            <form onSubmit={handleSubmit} className="form">
                <div className="form-group">
                    <label className="label">
                        Nome do estabelecimento:
                        <input
                            type="text"
                            value={nomeEmpresa}
                            onChange={(event) => setNomeEmpresa(event.target.value)}
                            className="input"
                            required
                        />
                    </label>
                </div>
                <div className="form-group">
                    <label className="label">
                        CEP:
                        <input
                            type="text"
                            value={cep}
                            onChange={(event) => setCep(event.target.value)}
                            className="input"
                            required
                        />
                    </label>
                </div>
                <div className="form-group">
                    <label className="label">
                        CNPJ:
                        <input
                            type="text"
                            value={cnpj}
                            onChange={(event) => setCnpj(event.target.value)}
                            className="input"
                            required
                        />
                    </label>
                </div>
                <div className="form-group">
                    <label className="label">
                        Tipo de Estabelecimento:
                        <input
                            type="text"
                            value={tipoEstabelecimento}
                            onChange={(event) => setTipoEstabelecimento(event.target.value)}
                            className="input"
                            required
                        />
                    </label>
                </div>
                <button type="submit" className="button">Cadastrar</button>
                <Link to="/registros" className="button">Ver Registros</Link>
                {mensagem && (
                    <div className={sucesso ? 'mensagem sucesso' : 'mensagem erro'}>
                        {mensagem}
                    </div>
                )}
            </form>
        </div>
    );
};

export default CadastroEstabelecimento;