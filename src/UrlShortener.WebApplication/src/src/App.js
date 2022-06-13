import React from "react";
import './App.css';

class App extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            url: "",
            originalUrl: "",
            urls: [],
        }
    }

    submitHandler = async (event) => {
        event.preventDefault();
        var requestOptions = {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
        };

        await fetch(`http://localhost:5167/url?Url=${this.state.originalUrl}`, requestOptions)
            .then(response => response.json())
            .then(shortUrl => {
                this.setState({ url: shortUrl.url });

            });
    }
               

    getAllHandler = async (event) => {
        event.preventDefault();
        var requestOptions = {
            method: 'GET',
            headers: { 'Content-type': 'application/json' },
        };

        await fetch('http://localhost:5167/url', requestOptions)
            .then(response => response.json())
            .then(urls => {
                this.setState({ urls });

            });
    }

    inputChangeHandler = (event) => {
        this.setState({ originalUrl: event.target.value });
    }


    render() {
        return (
            <div>
                <form onSubmit={this.submitHandler}>
                    <input type="text" placeholder="pass url" onChange={this.inputChangeHandler} />
                    <button>submit</button>
                </form>
                <div><a href={this.state.url}>{this.state.url}</a></div>
                <button onClick={this.getAllHandler}>GetAll</button>
                <table>
                    {this.state.urls.map((url =>
                        <tr>
                            <td><a href={url.originalUrl}>{url.originalUrl}</a></td>
                            <td><a href={url.shortUrl}>{url.shortUrl}</a></td>
                        </tr>
                    ))}
                </table>
            </div>
        )
    }
}

export default App;
