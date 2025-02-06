
<template>
	<div>

	

		<!-- Projects Table -->
		<a-row :gutter="24" type="flex">

			<!-- Projects Table Column -->
			<a-col :span="24" class="mb-24">

				<!-- Projects Table Column -->
				<CardProjectTable2
					:data="table2Data"
					:columns="table2Columns"
				></CardProjectTable2>
				<!-- / Projects Table Column -->

			</a-col>
			<!-- / Projects Table Column -->
			
		</a-row>
		<!-- / Projects Table -->

		
		
	</div>
</template>

<script >

	// "Projects" table component.
	import CardProjectTable2 from '../components/Cards/CardProjectTable2' ;
	

	// "Projects" table list of columns and their properties.
	const table2Columns = [
		{
			title: 'CODE',
			dataIndex: 'code',
			scopedSlots: { customRender: 'code' },
			width: 100,
		},
		{
			title: 'NAME',
			dataIndex: 'name',
			width: 300,
		},
		{
			title: 'BUDGET',
			dataIndex: 'budget',
			class: 'font-semibold text-muted',
		},
		{
			title: 'STATUS',
			dataIndex: 'projectCategory',
			class: 'font-semibold text-muted text-sm',
		},
		{
			title: 'COMPLETION',
			scopedSlots: { customRender: 'projectStage' },
			dataIndex: 'projectStage ',
		},
		{
			title: '',
			scopedSlots: { customRender: 'editBtn' },
			width: 100,
		},
	];
	
	
	export default ({
		created() {
			this.$store.dispatch("project/initApp");
		},
		computed: {
			myValue() { return this.$store.state.project }
			},
		components: {
			CardProjectTable2
			
		},
		data() {
			return {
				
                    // Associating "Projects" table data with its corresponding property.
				table2Data: this.$store.state.project.projects.data,

				// Associating "Projects" table columns with its corresponding property.
				table2Columns: table2Columns,
			}
		},
		
	})

</script>

<style lang="scss">
</style>