export interface OptionButtonSideBar{
    text: string;
    onClick: () => void;
}

export interface SideBarProps{
    logo?: string;
    arrButtons: OptionButtonSideBar[];
    arrFooterButtons?: OptionButtonSideBar[]
    logOut: () => void;
}