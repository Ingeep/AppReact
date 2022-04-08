import React,{Component} from 'react';  
import  ReactDOM  from 'react-dom';
///import logo from './logo.svg';
import './App.css';
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {Modal,ModalBody,ModalFooter,ModalHeader} from 'reactstrap';
import {faEdit,faTrashAlt} from "@fortawesome/free-solid-svg-icons";



const url ='https://localhost:7203/api/cliente/';

class App extends Component { 
state={
  data:[],
  modalInsertar:false,
  form:{
    clienteId: '',
    nombre_Completo:'',
    cedula:'',
    direccion:'',
    sector:'',
    ciudad:'',
    provincia:'',
    telefono:'',
    correo_Electronico:'',
    fotografia:'',
    tipoModal:''
   
  }
}
 
peticionGet = () => {
  axios.get(url).then(response => {
    this.setState({data:response.data});
  }).catch(err => {
    console.log(err.message);
  })
}

peticionPost = async () => {
  delete this.state.form.clienteId;
 await axios.post(url,this.state.form).then(response => {
    this.modalInsertar();
    this.peticionGet();
  }).catch(err => { 
    console.log(err.message);
  })
}

peticionPut = () => {
  axios.put(url+this.state.form.clienteId,this.state.form).then(response => {
    this.modalInsertar();
    this.peticionGet();
  }).catch(err => { 
    console.log(err.message);
  })
}

modalInsertar = () => {
  this.setState({modalInsertar: !this.state.modalInsertar});
}

selectCliente = (cliente) => {
  this.setState({
    tipoModal:'actualizar',
    form:{
    clienteId: cliente.clienteId,
    nombre_Completo:cliente.nombre_Completo,
    cedula:cliente.cedula,
    direccion:cliente.direccion,
    sector:cliente.sector,
    ciudad:cliente.ciudad,
    provincia:cliente.provincia,
    telefono:cliente.telefono,
    correo_Electronico:cliente.correo_Electronico,
    fotografia:cliente.fotografia,
    }
  })
  console.log(cliente)
}



handleChange = async e => {
  e.persist();
  await this.setState({
    form:{
       ...this.state.form,
       [e.target.name]: e.target.value
    }
  });
  console.log(this.state.form);
}


componentDidMount() {
   this.peticionGet();
  }

  render() {
    const {form} = this.state;
  return (
    <div className="App">
     <br />
     <button className="btn btn-success" onClick={() =>{this.setState({form:null,tipoModal:'insertar'}); this.modalInsertar()}}>Agregar Cliente</button>
     <br/><br/>
     <table className="table">
       <thead>
         <tr align="left">
           <th>ID</th>
           <th>Nombre</th>
           <th>Cédula</th>
           <th>Dirección</th>
           <th>Sector</th>
           <th>ciudad</th>
           <th>Provincia</th>
           <th>Teléfono</th>
           <th>Correo electrónico </th>
           <th>Fotografía </th>
         </tr>
       </thead>
       <tbody>
        {this.state.data.map(cliente => {
          return (
            <tr align="left">
            <td>{cliente.clienteId}</td>
            <td>{cliente.nombre_Completo}</td>
            <td>{cliente.cedula}</td>
            <td>{cliente.direccion}</td>
            <td>{cliente.sector}</td>
            <td>{cliente.ciudad}</td>
            <td>{cliente.provincia}</td>
            <td>{cliente.telefono}</td>
            <td>{cliente.correo_Electronico}</td>
            <td>{cliente.fotografia}</td>
           
            <td>
              <button className="btn btn-primary" onClick={() => {this.selectCliente(cliente); this.modalInsertar()}}><FontAwesomeIcon icon={faEdit}/></button>
              {" "}
              <button className="btn btn-danger"><FontAwesomeIcon icon={faTrashAlt}/></button>
            </td>
          </tr>
          )})
        }
       </tbody>
     </table>

   <Modal isOpen={this.state.modalInsertar}>
       <ModalHeader style={{display: 'block'}}>
         <span style={{float: 'right'}} >x</span>
       </ModalHeader>
       <ModalBody>
         <div className="form-group">
           <label htmlFor='clienteId'>ID</label>
           <input className="form-control" type="text" name="clienteId" id="clienteId" readOnly onChange={this.handleChange} value={form?form.clienteId: this.state.data.length +1}/>
           <br />
           <label htmlFor='nombre_Completo'>Nombre</label>
           <input className="form-control" type="text" name="nombre_Completo" id="nombre_Completo" onChange={this.handleChange} value={form?form.nombre_Completo:''}/>
           <br />
           <label htmlFor='cedula'>Cédula</label>
           <input className="form-control" type="text" name="cedula" id="cedula" onChange={this.handleChange} value={form?form.cedula:''}/>
           <br />
           <label htmlFor='direccion'>Dirección</label>
           <input className="form-control" type="text" name="direccion" id="direccion" onChange={this.handleChange} value={form?form.direccion:''}/>
           <br />
           <label htmlFor='sector'>Sector</label>
           <input className="form-control" type="text" name="sector" id="sector" onChange={this.handleChange} value={form?form.sector:''}/>
           <br />
           <label htmlFor='ciudad'>Ciudad</label>
           <input className="form-control" type="text" name="ciudad" id="ciudad" onChange={this.handleChange} value={form?form.ciudad:''}/>
           <br />
           <label htmlFor='provincia'>Provincia</label>
           <input className="form-control" type="text" name="provincia" id="provincia" onChange={this.handleChange} value={form?form.provincia:''}/>
           <br />
           <label htmlFor='telefono'>Teléfono</label>
           <input className="form-control" type="tel" name="telefono" id="telefono" onChange={this.handleChange} value={form?form.telefono:''}/>
           <br />
           <label htmlFor='correo_Electronico'>Correo electrónico </label>
           <input className="form-control" type="email" name="correo_Electronico" id="correo_Electronico" onChange={this.handleChange} value={form?form.correo_Electronico:''}/>
           <br />
           <label htmlFor='fotografia'>Fotografía</label>
           <input className="form-control" type="text" name="fotografia" id="fotografia" onChange={this.handleChange} value={form?form.fotografia:''}/>
         </div>
       </ModalBody>

       <ModalFooter>
         {this.state.tipoModal == 'insertar'?
         <button className="btn btn-success" onClick={() => this.peticionPost()}>
           Insertar
         </button>:<button className="btn btn-primary" onClick={() => this.peticionPut()}>Actualizar</button>
         }
         <button className="btn btn-danger" onClick={() => this.modalInsertar()}>Cancelar</button>
       </ModalFooter>
     </Modal>



    </div>
  );
}
}
export default App;

