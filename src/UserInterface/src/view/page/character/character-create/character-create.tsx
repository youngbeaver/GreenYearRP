import { useState, useEffect } from "react";
import { fatherList, motherList } from "./parents";

export default function CharacterCreate() {
    const [data, setData] = useState < {
        gender: string;
        firstName: string;
        secondName: string;
        father: keyof typeof fatherList | "";
        mother: keyof typeof motherList | "";
        val: number
    } > ({
        gender: "",
        firstName: "",
        secondName: "",
        father: "",
        mother: "",
        val: 1
    });

    useEffect(() => {
        mp.trigger("client:localEditCharacter");
    }, [data])

    return (
        <div>
            <label>
                <input
                    type="radio"
                    value="Man"
                    checked={data.gender === 'Man'}
                    onChange={() => setData(prev => ({ ...prev, gender: 'Man' }))}
                />
                Мужской пол
            </label>

            <label>
                <input
                    type="radio"
                    value="Woman"
                    checked={data.gender === 'Woman'}
                    onChange={() => setData(prev => ({ ...prev, gender: 'Woman' }))}
                />
                Женский пол
            </label>

            <input type="text" placeholder="Введите имя" value={data.firstName} onChange={(e) => setData(prev => ({ ...prev, firstName: e.target.value }))}/>
            <input type="text" placeholder="Введите фамилию" value={data.secondName} onChange={(e) => setData(prev => ({ ...prev, secondName: e.target.value }))}></input>

            <label>
                Выберите первый вариант:
                <select value={data.father} onChange={(e) => setData(prev => ({ ...prev, father: e.target.value ? Number(e.target.value) : "", }))}>
                    <option value="">Выберите отца</option>
                    {Object.keys(fatherList).map((key) => (
                        <option key={key} value={key}>
                            {fatherList[Number(key)]}
                        </option>
                    ))}
                </select>
            </label>

            <br />

            <label>
                Выберите второй вариант:
                <select value={data.mother} onChange={(e) => setData(prev => ({ ...prev, mother: e.target.value ? Number(e.target.value) : "", }))}>
                    <option value="">Выберите мать</option>
                    {Object.keys(motherList).map((key) => (
                        <option key={key} value={key}>
                            {motherList[Number(key)]}
                        </option>
                    ))}
                </select>
            </label>

            <p>Результат: Отец — {fatherList[Number(data.father)]}, Мать — {motherList[Number(data.mother)]}</p>
            <input type="range" min="1" max="100" value={data.val} onChange={e => setData(prev => ({ ...prev, val: Number(e.target.value) }))}></input>
            <p>Результат: {data.val / 100}</p>
        </div>

       
    )
}