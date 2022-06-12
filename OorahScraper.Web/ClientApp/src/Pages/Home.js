import React, { useState } from "react";
import axios from "axios";

const Home = () => {

    const [prizes, setPrizes] = useState()
    const [loading, setLoading] = useState(false);

    const onButtonClick = async () => {
        setLoading(true);
        setPrizes([]);
        const { data } = await axios.get('/api/prize/gettenprizes');
        setPrizes(data);
        setLoading(false);
    }

    return (
        < div className="container" >
            <div className="row mt-5">
                <button className="btn btn-info btn-block" onClick={onButtonClick}>
                    Click to view any ten spectacular prizes from the Oorah Aution!
                </button>
            </div>
            {loading && <h1>loading...</h1>}
            {prizes && <div>
                <table className='table table-hover table-striped table-bordered'>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Image</th>
                            <th>Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        {prizes.map(p =>
                            <tr>
                                <td>{p.title}</td>

                                <td><img src={p.imageUrl} width='190' height='150' /></td>
                                <td>ONLY $5.00!!!</td>
                            </tr>)}

                    </tbody>
                </table>
            </div>}


        </div >

    )

}
export default Home;