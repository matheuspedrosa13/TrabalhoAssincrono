import { OptionButtonSideBar } from "../../../components/SideBar/types"
import { RecomendationBoxProps } from "../../../components/RecomandationBox/types";


export interface HomeViewProps{
    arrButtons: OptionButtonSideBar[]
    arrButtonsFooter: OptionButtonSideBar[]
    logOut: () => void;
    recomendatioArr: RecomendationBoxProps[];
    onSearch: () => void;
    setSearchValue: (value : string) => void;
    searchValue: string;
}