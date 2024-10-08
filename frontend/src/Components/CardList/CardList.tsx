import React from 'react'
import Card from '../Card/Card'

interface Props {}

const CardList = (props: Props) => {
  return (
    <div>
        <Card companyName='Toyanimation' ticker='TAMA' price={234}/>
        <Card companyName='Sony' ticker='SOY' price={3454}/>
        <Card companyName='Facebook' ticker='F|b' price={123}/>
    </div>
  )
}

export default CardList