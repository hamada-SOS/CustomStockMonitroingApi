import React from 'react';
import "./Card.css";

type Props = {}

const Card = (props: Props) => {
  return (
    <div className='Card'>
      <img src="https://images.unsplash.com/photo-1727459500188-64b7e808659c?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" 
      alt="image" />
      <div className="details">
        <h2>price</h2>
        <p>details</p>
        <p className="info">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Accusamus, illum!</p>
      </div>
    </div>
  )
}

export default Card