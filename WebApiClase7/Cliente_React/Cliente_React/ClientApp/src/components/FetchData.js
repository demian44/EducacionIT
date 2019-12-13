import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = { amigos: [], loading: true };

        fetch('api/Amigos/Getamigos')
            .then(response => response.json())
            .then(data => {
                this.setState({ amigos: data, loading: false });
            });
    }
    static renderamigosTable(amigos) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Apellido</th>
                        <th>Nombre</th>
                    </tr>
                </thead>
                <tbody>
                    {amigos.map(amigos =>
                        <tr key={amigos.id}>
                            <td>{amigos.id}</td>
                            <td>{amigos.apellido}</td>
                            <td>{amigos.nombre}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Cargando...</em></p>
            : FetchData.renderamigosTable(this.state.amigos);

        return (
            <div>
                <h1>Lista de amigos</h1>
                <p>Cargando amigos desde WEB API</p>
                {contents}
            </div>
        );
    }
}

