import { useEffect, useState } from 'react';
import baseApi from '../../api';

const ListaEstabelecimentos = () => {

    const [estabelecimentos, setEstabelecimentos] = useState([]);

    useEffect(() => {
        const fetchEstabelecimentos = async () => {
            try {
                const response = await baseApi.get('/Estabelecimentos');
                setEstabelecimentos(response.data);
            } catch (error) {
                console.error(error);
            }
        };

        fetchEstabelecimentos();
    }, []);

    const handleRemoverRegistro = async (id) => {
        try {
            await baseApi.delete(`/Estabelecimentos/${id}`);
            setEstabelecimentos(estabelecimentos.filter(estabelecimento => estabelecimento.id !== id));
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div className="container">
            <h1>Registros de clubes e centros esportivos</h1>
            {estabelecimentos.length === 0 ? (
                <p>Nenhum estabelecimento encontrado.</p>
            ) : (
                <table className="table">
                    <thead>
                        <tr>
                            <th>Nome da Empresa</th>
                            <th>CEP</th>
                            <th>CNPJ</th>
                            <th>Tipo de Estabelecimento</th>
                            <th>Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        {estabelecimentos.map((estabelecimento) => (
                            <tr key={estabelecimento.id}>
                                <td>{estabelecimento.nomeEmpresa}</td>
                                <td>{estabelecimento.cep}</td>
                                <td>{estabelecimento.cnpj}</td>
                                <td>{estabelecimento.tipoEstabelecimento}</td>
                                <td>
                                    <button
                                        onClick={() => handleRemoverRegistro(estabelecimento.id)}
                                        className="button-remover"
                                    >
                                        Remover
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
};

export default ListaEstabelecimentos