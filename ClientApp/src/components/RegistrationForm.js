import React from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { USERS_API_URL } from '../Constants/index';
class RegistrationForm extends React.Component {
    state = {
        id: 0,
        product_name: '',
        stock_quantity: '',
        category: '',
        URL: ''
    }
    componentDidMount() {
        if (this.props.user) {
            const { id, product_name, stock_quantity, categories,URL  } = this.props.user
            this.setState({ id, product_name, stock_quantity, categories, URL });
        }
    }
    onChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }
    submitNew = e => {
        e.preventDefault();
        fetch(`${USERS_API_URL}`, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                product_name: this.state.product_name,
                categories: this.state.categories,
                URL: this.state.URL,
                stock_quantity: this.state.stock_quantity
            })
        })
            .then(res => res.json())
            .then(user => {
                this.props.addUserToState(user);
                this.props.toggle();
            })
            .catch(err => console.log(err));
    }
    submitEdit = e => {
        e.preventDefault();
        fetch(`${USERS_API_URL}/${this.state.id}`, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: this.state.id,
                product_name: this.state.product_name,
                categories: this.state.categories,
                URL: this.state.URL,
                stock_quantity: this.state.stock_quantity
            })
        })
            .then(() => {
                this.props.toggle();
                this.props.updateUserIntoState(this.state.id);
            })
            .catch(err => console.log(err));
    }
    render() {
        return <Form onSubmit={this.props.user ? this.submitEdit : this.submitNew}>
            <FormGroup>
                <Label for="product_name">Product:</Label>
                <Input type="text" name="product_name" onChange={this.onChange} value={this.state.product_name === '' ? '' : this.state.product_name} />
            </FormGroup>
            <FormGroup>
                <Label for="stock_quantity">How Many</Label>
                <Input type="text" name="stock_quantity" onChange={this.onChange} value={this.state.stock_quantity === '' ? '' : this.state.stock_quantity} />
            </FormGroup>
            <FormGroup>
                <Label for="categories">Category</Label>
                <Input type="text" name="category" onChange={this.onChange} value={this.state.categories === '' ? '' : this.state.categories} />
            </FormGroup>
            <FormGroup>
                <Label for="des_box">Description</Label>
                <Input type="text" name="des_box" onChange={this.onChange} value={this.state.URL === '' ? '' : this.state.des_box}
                    placeholder="./image/" />
            </FormGroup>
            <Button>Send</Button>
        </Form>;
    }
}
export default RegistrationForm;