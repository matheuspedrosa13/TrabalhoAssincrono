import { useEffect, useState } from 'react';
import './style.less';
import { GrayInputProps } from './types/';
import { CiCircleInfo } from "react-icons/ci";

export function GrayInput({
    placeHolder,
    value,
    setValue,
    errorMessage,
    isError,
    isTitleFixed,
    required
}: GrayInputProps) {
    return (
        <div className='GrayInput'>
            <div className="input" >
                {isTitleFixed ? (
                    <h2>{placeHolder}</h2>                    
                ) : 
                (
                    value.length !== 0 && (
                        <h2>{placeHolder}</h2>
                    )
                    
                )
                }
                <input type="text"
                    placeholder={placeHolder}
                    onChange={(e) => setValue(e.target.value)}
                    required={required}
                />
            </div>
            {isError &&
                <p className='errorMessage'>{errorMessage && <CiCircleInfo fontSize={'1rem'} />}{errorMessage}</p>
            }
        </div>
    );
}